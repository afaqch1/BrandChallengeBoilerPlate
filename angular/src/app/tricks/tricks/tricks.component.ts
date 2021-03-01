import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { TrickDto, TrickDtoPagedResultDto, TrickServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateTrickDialogComponent } from './create-trick/create-trick-dialog.component';
import { EditTrickDialogComponent } from './edit-trick/edit-trick-dialog.component';

class PagedTricksRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({
  selector: 'app-tricks',
  templateUrl: './tricks.component.html',
  styleUrls: ['./tricks.component.css'],
  animations: [appModuleAnimation()]
})
export class TricksComponent extends PagedListingComponentBase<TrickDto> {
  Tricks: TrickDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _TrickService: TrickServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createTrick(): void {
    this.showCreateOrEditTrickDialog();
  }

  editTrick(Trick: TrickDto): void {
    this.showCreateOrEditTrickDialog(Trick.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.getDataPage(1);
  }

  protected list(
    request:PagedTricksRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._TrickService
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
      .subscribe((result: TrickDtoPagedResultDto) => {
        this.Tricks = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(Trick: TrickDto): void {
    abp.message.confirm(
      this.l('TrickDeleteWarningMessage', Trick.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._TrickService.delete(Trick.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditTrickDialog(id?: string): void {
    let createOrEditTrickDialog: BsModalRef;
    if (!id) {
      createOrEditTrickDialog = this._modalService.show(
        CreateTrickDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditTrickDialog = this._modalService.show(
        EditTrickDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditTrickDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  check():void{
      var x = Math.floor(Math.random() * (1 - 0 + 1) + 0);
     if(x==1){
       alert("Your trick matched!\n You get 10 points");
     }
     else{
      alert("Oops better luck next time !");
     }
  }
}
