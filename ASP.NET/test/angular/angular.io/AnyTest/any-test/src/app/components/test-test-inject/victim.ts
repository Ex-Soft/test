import { InjectionToken } from '@angular/core';

import { SmthClass } from '../../classes';

export const VICTIM_VALUE: SmthClass = new SmthClass('SmthClass.nameValue');

export const VICTIM_INJECTION_TOKEN = new InjectionToken<SmthClass>('VictimInjectionToken');
