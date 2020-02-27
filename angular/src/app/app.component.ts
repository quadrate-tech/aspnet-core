import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { SignalRAspNetCoreHelper } from '@shared/helpers/SignalRAspNetCoreHelper';
import { slideFromBottom } from '@shared/animations/routerTransition';
import { AppAuthService } from '@shared/auth/app-auth.service';
import * as _ from 'lodash';

@Component({
  templateUrl: './app.component.html',
  animations: [slideFromBottom]
})
export class AppComponent extends AppComponentBase implements OnInit {
  shownLoginName = '';
  languages: abp.localization.ILanguageInfo[];
  currentLanguage: abp.localization.ILanguageInfo;

  constructor(injector: Injector, private _authService: AppAuthService) {
    super(injector);
  }

  ngOnInit(): void {
    this.shownLoginName = this.appSession.getShownLoginName();

    SignalRAspNetCoreHelper.initSignalR();

    abp.event.on('abp.notifications.received', userNotification => {
      abp.notifications.showUiNotifyForUserNotification(userNotification);

      // Desktop notification
      Push.create('AbpZeroTemplate', {
        body: userNotification.notification.data.message,
        icon: abp.appPath + 'assets/app-logo-small.png',
        timeout: 6000,
        onClick: function() {
          window.focus();
          this.close();
        }
      });
    });

    this.languages = _.filter(this.localization.languages, l => !l.isDisabled);
    this.currentLanguage = this.localization.currentLanguage;
  }

  logout(): void {
    this._authService.logout();
  }

  changeLanguage(languageName: string): void {
    console.log('not_implemented_yet:');
  }
}
