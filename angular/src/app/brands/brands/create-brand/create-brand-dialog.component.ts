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
  BrandServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-brand-dialog.component.html'
})
export class CreateBrandDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  brand: BrandDto = new BrandDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _brandService: BrandServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    //this.brand.isActive = true;
  }

  save(): void {
    this.saving = true;

    this._brandService
      .create(this.brand)
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
