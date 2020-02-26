import { Component, ViewEncapsulation, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { slideFromBottom } from '@shared/animations/routerTransition';

@Component({
  templateUrl: './account.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [slideFromBottom]
})
export class AccountComponent extends AppComponentBase {
  versionText: string;
  currentYear: number;

  public constructor(injector: Injector) {
    super(injector);

    this.currentYear = new Date().getFullYear();
    this.versionText =
      this.appSession.application.version +
      ' [' +
      this.appSession.application.releaseDate.format('YYYYDDMM') +
      ']';
  }
}
