import { Component, OnInit } from '@angular/core';
import { FormGroup, AbstractControl, FormControl, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';

export class TestAngularEditorComponentErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null): boolean {
    return control != null && control.invalid;
  }
}

@Component({
  selector: 'app-test-angular-editor',
  templateUrl: './test-angular-editor.component.html',
  styleUrls: ['./test-angular-editor.component.css']
})
export class TestAngularEditorComponent implements OnInit {
  matcher = new TestAngularEditorComponentErrorStateMatcher();
  formGroup!: FormGroup;
  title!: FormControl;
  text!: FormControl;

  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    translate: 'no',
    sanitize: true,
    toolbarPosition: 'top',
    defaultFontSize: '4',
    placeholder: 'Enter the body',
    defaultParagraphSeparator: 'p',
    toolbarHiddenButtons: [
      ['undo', 'redo', 'subscript', 'superscript', 'justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull', 'indent', 'outdent', 'insertUnorderedList', 'insertOrderedList', 'heading', 'fontName'],
      ['fontSize', 'customClasses', 'insertImage', 'insertVideo', 'insertHorizontalRule', 'removeFormat', 'toggleEditorMode']
    ]
  };

  constructor() {}

  ngOnInit(): void {
    this.createFormControls();
    this.createForm();
  }

  private createFormControls(): void {
    this.title = new FormControl('', [Validators.required]);
    this.text = new FormControl('', [Validators.required]);
  }

  private createForm(): void {
    this.formGroup = new FormGroup({
      title: this.title,
      text: this.text
    }, [this.validateForm]);
  }

  private validateForm(control: AbstractControl) {
    if (control instanceof FormGroup) {
      console.log(control);
    }

    return null;
  }
}
