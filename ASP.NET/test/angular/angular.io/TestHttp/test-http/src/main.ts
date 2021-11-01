import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import { enableAkitaProdMode, persistState, PersistStateSelectFn } from '@datorama/akita';

if (environment.production) {
  enableProdMode();
  enableAkitaProdMode();
}

export const localStorageKey = 'Akita';

const selectTockenItems: PersistStateSelectFn = (state) => ({ items: Object.values(state.entities) });
selectTockenItems.storeName = 'items';
const selectTockenItemsWithEnum: PersistStateSelectFn = (state) => ({ items: Object.values(state.entities) });
selectTockenItemsWithEnum.storeName = 'itemswithenum';

persistState({
  key: localStorageKey,
  include: [ 'items', 'itemswithenum' ],
  storage: localStorage,
  select: [ selectTockenItems, selectTockenItemsWithEnum ],
});

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch(err => console.error(err));
