import { AppConsts } from '@shared/AppConsts';
import { XmlHttpRequestHelper } from '@shared/helpers/XmlHttpRequestHelper';
import { environment } from './environments/environment';
import * as _ from 'lodash';
import * as moment from 'moment';

export class AppPreBootstrap {
  static run(appRootUrl: string, callback: () => void): void {
    AppPreBootstrap.getApplicationConfig(appRootUrl, () => {
      AppPreBootstrap.getUserConfiguration(callback);
    });
  }

  private static getApplicationConfig(
    appRootUrl: string,
    callback: () => void
  ): void {
    XmlHttpRequestHelper.ajax(
      'GET',
      appRootUrl + 'assets/' + environment.appConfig,
      [
        {
          name: 'Abp.TenantId',
          value: abp.multiTenancy.getTenantIdCookie() + ''
        }
      ],
      null,
      result => {
        debugger;
        AppConsts.appBaseUrl = result.appBaseUrl;
        AppConsts.remoteServiceBaseUrl = result.remoteServiceBaseUrl;
        AppConsts.localeMappings = result.localeMappings;
        callback();
      }
    );
  }

  private static getCurrentClockProvider(
    currentProviderName: string
  ): abp.timing.IClockProvider {
    if (currentProviderName === 'unspecifiedClockProvider') {
      return abp.timing.unspecifiedClockProvider;
    }

    if (currentProviderName === 'utcClockProvider') {
      return abp.timing.utcClockProvider;
    }

    return abp.timing.localClockProvider;
  }

  private static getUserConfiguration(callback: () => void): any {
    return XmlHttpRequestHelper.ajax(
      'GET',
      AppConsts.remoteServiceBaseUrl + '/AbpUserConfiguration/GetAll',
      {
        Authorization: 'Bearer ' + abp.auth.getToken(),
        '.AspNetCore.Culture': abp.utils.getCookieValue(
          'Abp.Localization.CultureName'
        ),
        'Abp.TenantId': abp.multiTenancy.getTenantIdCookie()
      },
      null,
      response => {
        debugger;
        _.merge(abp, response.result);
        debugger;
        abp.clock.provider = this.getCurrentClockProvider(
          response.result.clock.provider
        );

        moment.locale(abp.localization.currentLanguage.name);

        if (abp.clock.provider.supportsMultipleTimezone) {
          moment.tz.setDefault(abp.timing.timeZoneInfo.iana.timeZoneId);
        }

        callback();
      }
    );
  }
}
