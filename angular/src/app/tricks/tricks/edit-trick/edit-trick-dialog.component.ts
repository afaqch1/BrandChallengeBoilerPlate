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
  TrickServiceProxy,
  TrickDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-trick-dialog.component.html'
})
export class EditTrickDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  trick: TrickDto = new TrickDto();
  id: string;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _trickService: TrickServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._trickService.get(this.id).subscribe((result: TrickDto) => {
      this.trick = result;
    });
  }

  save(): void {
    this.saving = true;

    this._trickService
      .update(this.trick)
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
