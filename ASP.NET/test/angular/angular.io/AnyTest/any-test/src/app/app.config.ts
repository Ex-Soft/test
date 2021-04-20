import { InjectionToken } from '@angular/core';

import { IAppConfig } from './classes/iapp-config';

export const APP_DI_CONFIG: IAppConfig = {
    p1: 'AppConfig.p1Value'
};

export const APP_CONFIG = new InjectionToken<IAppConfig>('app.config');
