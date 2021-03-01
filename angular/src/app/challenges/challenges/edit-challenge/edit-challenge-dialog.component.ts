import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ChallengeServiceProxy,
  ChallengeDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-challenge-dialog.component.html'
})
export class EditChallengeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  challenge: ChallengeDto = new ChallengeDto();
  id: string;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _challengeService: ChallengeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._challengeService.get(this.id).subscribe((result: ChallengeDto) => {
      this.challenge = result;
    });
  }

  save(): void {
    this.saving = true;

    this._challengeService
      .update(this.challenge)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
