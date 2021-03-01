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
  BrandDto,
  ChallengeDto,
  ChallengeServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-challenge-dialog.component.html'
})
export class CreateChallengeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  challenge: ChallengeDto = new ChallengeDto();
  brand:BrandDto=new BrandDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _challengeService: ChallengeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    //this.challenge.isActive = true;
  }

  save(): void {
    this.saving = true;

    this._challengeService
      .create(this.challenge)
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
