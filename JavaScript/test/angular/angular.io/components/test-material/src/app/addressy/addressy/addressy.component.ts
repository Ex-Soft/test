import { Component, Input, OnInit, ViewChild, Output, EventEmitter, OnDestroy } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { Subject } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';
import { MatAutocompleteTrigger, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';

export interface AddressyError {
  Error?: string;
  Description?: string;
  Cause?: string;
  Resolution?: string;
}

export interface AddressyFindAddress {
  Id: string;
  Type: string;
  Text: string;
  Description: string;
}

export interface AddressyFindAddressResponse {
  Items: AddressyFindAddress[];
}

export interface AddressyRetriveAddress {
  SubBuilding: string;
  PostalCode: string;
  City: string;
  ProvinceCode: string;
  CountryIso2: string;
  Field1: string;
}

export interface AddressyRetriveAddressResponse {
  Items: AddressyRetriveAddress[];
}

@Component({
  selector: 'app-addressy',
  templateUrl: './addressy.component.html',
  styleUrls: ['./addressy.component.css']
})
export class AddressyComponent implements OnInit, OnDestroy {
  @Input() country: string;
  @Input() key: string;
  @Input() required: boolean;

  @Output() addressSelectedEvent = new EventEmitter<any>();
  @Output() enterAddressManuallyEvent = new EventEmitter();
  @Output() errorEvent = new EventEmitter<AddressyError>();

  @ViewChild('autoCompleteInput', { read: MatAutocompleteTrigger, static: false }) autoComplete: MatAutocompleteTrigger;

  destroy$: Subject<boolean> = new Subject<boolean>();

  enterAddressManuallyOptionId = '-1';
  enterAddressManuallyOption = {
    Id: this.enterAddressManuallyOptionId,
    Text: 'Don\'t see your address?',
  } as AddressyFindAddress;

  findUrl = 'https://api.addressy.com/Capture/Interactive/Find/v1.10/json3.ws';
  retrieveUrl = 'https://api.addressy.com/Capture/Interactive/Retrieve/v1.00/json3.ws';

  controlInput = new FormControl();
  addresses: AddressyFindAddress[];
  isClearing: boolean;

  constructor(
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
    this.controlInput.valueChanges
      .pipe(takeUntil(this.destroy$))
      .subscribe(value => this.onControlInputValueChanged(value));
  }

  ngOnDestroy(): void {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }

  onControlInputValueChanged(text): void {
    if (typeof text !== 'string' || this.isClearing) {
      return;
    }

    if (!text.length && Array.isArray(this.addresses) && this.addresses.length) {
      this.onClearClick();
      return;
    }

    this.findAddresses(text);
  }

  onClearClick(): void {
    this.isClearing = true;
    this.controlInput.setValue('');
    this.addresses = [] as AddressyFindAddress[];
    this.isClearing = false;
  }

  onOptionSelected(event: MatAutocompleteSelectedEvent): void {
    const address = event && event.option ? event.option.value as AddressyFindAddress : undefined;

    if (!address) {
      return;
    }

    if (address.Id === this.enterAddressManuallyOptionId) {
      this.onEnterAddressManuallyClick();
      return;
    }

    if (address.Type === 'Address') {
      this.retrieveAddress(address.Id);
    } else {
      this.findAddresses(undefined, address.Id);
    }
  }

  onEnterAddressManuallyClick(): void {
    this.onClearClick();
    this.enterAddressManuallyEvent.emit();
  }

  displayFn = (address: AddressyFindAddress): string => {
    return address && address.Id !== this.enterAddressManuallyOptionId ? address.Text : '';
  }

  private findAddresses(text?: string, container?: string): void {
    let params = `Key=${encodeURIComponent(this.key)}&Countries=${encodeURIComponent(this.country)}`;
    if (!!text) {
      params += `&Text=${encodeURIComponent(text)}`;
    }
    if (!!container) {
      params += `&Container=${encodeURIComponent(container)}`;
    }

    this.httpClient.get<AddressyFindAddressResponse>(`${this.findUrl}?${params}`)
      .pipe(map(data => data.Items))
      .subscribe(
        addresses => {
          if (!Array.isArray(addresses) || !addresses.length) {
            return;
          }

          if (this.checkAddressyError(addresses[0])) {
            return;
          }

          addresses.splice(0, 0, this.enterAddressManuallyOption);
          this.addresses = addresses;

          if (container && this.autoComplete) {
            this.autoComplete.openPanel();
          }
        },
        error => this.handleError(error)
      );
  }

  private retrieveAddress(id: string): void {
    const params = `Key=${encodeURIComponent(this.key)}&Id=${encodeURIComponent(id)}&Field1Format={StreetAddress}`;
    this.httpClient.get<AddressyRetriveAddressResponse>(`${this.retrieveUrl}?${params}`)
      .subscribe(
        data => {
          if (!data || !Array.isArray(data.Items) || !data.Items.length) {
            return;
          }

          if (this.checkAddressyError(data.Items[0])) {
            return;
          }

          const address = data.Items[0] as AddressyRetriveAddress;
          const selectedAddress = {
            line1: address.Field1,
            line2: address.SubBuilding,
            postalCode: address.PostalCode,
            city: address.City,
            state: address.ProvinceCode,
            country: address.CountryIso2
          };

          this.addressSelectedEvent.emit(selectedAddress);
          this.onClearClick();
        },
        error => this.handleError(error)
      );
  }

  private checkAddressyError(obj): boolean {
    const addressyError = this.getAddressyError(obj);
    if (addressyError) {
      this.errorEvent.emit(addressyError);
    }
    return Boolean(addressyError);
  }

  private getAddressyError(obj): AddressyError {
    return obj.hasOwnProperty('Error') ? obj as AddressyError : undefined;
  }

  private handleError(error: HttpErrorResponse): void {
    let addressyError = { Description: 'Unknown error!'} as AddressyError;
    if (error.error instanceof ErrorEvent) {
      addressyError.Description = error.error.message;
    } else {
      addressyError = { Error: error.status.toString(), Description: error.message } as AddressyError;
    }

    this.errorEvent.emit(addressyError);
  }
}
