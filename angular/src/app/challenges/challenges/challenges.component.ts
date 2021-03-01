import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { ChallengeDto, ChallengeDtoPagedResultDto, ChallengeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateChallengeDialogComponent } from './create-challenge/create-challenge-dialog.component';
import { EditChallengeDialogComponent } from './edit-challenge/edit-challenge-dialog.component';

class PagedChallengesRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({
  selector: 'app-challenges',
  templateUrl: './challenges.component.html',
  styleUrls: ['./challenges.component.css'],
  animations: [appModuleAnimation()]
})
export class ChallengesComponent extends PagedListingComponentBase<ChallengeDto> {
  Challenges: ChallengeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _ChallengeService: ChallengeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createChallenge(): void {
    this.showCreateOrEditChallengeDialog();
  }

  editChallenge(Challenge: ChallengeDto): void {
    this.showCreateOrEditChallengeDialog(Challenge.id);
  }

  clearFilters(): void {
    this.keyword = '';
    this.getDataPage(1);
  }

  protected list(
    request:PagedChallengesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._ChallengeService
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
      .subscribe((result: ChallengeDtoPagedResultDto) => {
        this.Challenges = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(Challenge: ChallengeDto): void {
    abp.message.confirm(
      this.l('ChallengeDeleteWarningMessage', Challenge.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._ChallengeService.delete(Challenge.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  private showCreateOrEditChallengeDialog(id?: string): void {
    let createOrEditChallengeDialog: BsModalRef;
    if (!id) {
      createOrEditChallengeDialog = this._modalService.show(
        CreateChallengeDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditChallengeDialog = this._modalService.show(
        EditChallengeDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditChallengeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
  
}
