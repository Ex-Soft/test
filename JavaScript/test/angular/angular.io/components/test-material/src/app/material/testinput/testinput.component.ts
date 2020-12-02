import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-test-input',
  templateUrl: './testinput.component.html',
  styleUrls: ['./testinput.component.css']
})
export class TestinputComponent implements OnInit {
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  emailFormControl2 = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  formGroup = new FormGroup({
    emailFormControl: this.emailFormControl,
    emailFormControl2: this.emailFormControl2,
  });

  matcher = new MyErrorStateMatcher();

  ngOnInit(): void {
    this.emailFormControl.valueChanges.subscribe(value => console.log(value));
    this.formGroup.setValue({ emailFormControl: 'blah-blah-blah@1.com', emailFormControl2: 'blah-blah-blah@1.com' });
  }
}
