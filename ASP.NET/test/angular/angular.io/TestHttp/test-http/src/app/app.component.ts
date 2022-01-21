import { Component, OnInit } from '@angular/core';
import { fromEvent } from 'rxjs';
import { filter } from 'rxjs/operators';
import { snapshotManager } from '@datorama/akita';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { localStorageKey } from '../main';

@UntilDestroy()
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'test-http';

  ngOnInit(): void {
    this._addStorageEventListener();
  }

  // https://dev.to/arielgueta/keeping-browser-tabs-in-sync-using-localstorage-angular-akita-p39
  private _addStorageEventListener(): void {
    fromEvent<StorageEvent>(window, 'storage')
    .pipe(
      filter(event => event.key === localStorageKey),
      untilDestroyed(this)
    )
    .subscribe(event => {
      snapshotManager.setStoresSnapshot(event.newValue, { skipStorageUpdate: true });
    });
  }
}
