import { Component, Injector, OnInit } from '@angular/core';
import { CreateChallengeDialogComponent } from '@app/challenges/challenges/create-challenge/create-challenge-dialog.component';
import { EditChallengeDialogComponent } from '@app/challenges/challenges/edit-challenge/edit-challenge-dialog.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { BrandDto, BrandDtoPagedResultDto, BrandServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateBrandDialogComponent } from './create-brand/create-brand-dialog.component';
import { EditBrandDialogComponent } from './edit-brand/edit-brand-dialog.component';

class PagedBrandsRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css'],
  animations: [appModuleAnimation()]
})
export class BrandsComponent extends PagedListingComponentBase<BrandDto>{
  Brands: BrandDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _BrandService: BrandServiceProxy,
    private _modalService: BsModalService,
  ) {
    super(injector);
  }
  createBrand(): void {
    this.showCreateOrEditBrandDialog();
  }

  editBrand(Brand: BrandDto): void {
    this.showCreateOrEditBrandDialog(Brand.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.getDataPage(1);
  }

  protected list(
    request:PagedBrandsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._BrandService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: BrandDtoPagedResultDto) => {
        this.Brands = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(Brand: BrandDto): void {
    abp.message.confirm(
      this.l('BrandDeleteWarningMessage', Brand.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._BrandService.delete(Brand.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditBrandDialog(id?: string): void {
    let createOrEditBrandDialog: BsModalRef;
    if (!id) {
      createOrEditBrandDialog = this._modalService.show(
        CreateBrandDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditBrandDialog = this._modalService.show(
        EditBrandDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditBrandDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  
}
