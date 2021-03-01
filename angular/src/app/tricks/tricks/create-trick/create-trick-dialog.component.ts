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
  TrickDto,
  TrickServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-trick-dialog.component.html'
})
export class CreateTrickDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  trick: TrickDto = new TrickDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _trickService: TrickServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    //this.trick.isActive = true;
  }

  save(): void {
    this.saving = true;

    this._trickService
      .create(this.trick)
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
