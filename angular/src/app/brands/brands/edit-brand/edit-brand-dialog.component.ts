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
  BrandServiceProxy,
  BrandDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-brand-dialog.component.html'
})
export class EditBrandDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  brand: BrandDto = new BrandDto();
  id: string;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _brandService: BrandServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._brandService.get(this.id).subscribe((result: BrandDto) => {
      this.brand = result;
    });
  }

  save(): void {
    this.saving = true;

    this._brandService
      .update(this.brand)
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
