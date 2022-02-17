import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { AngularEditorConfig } from '@kolkov/angular-editor';

@Component({
  selector: 'app-test-angular-editor',
  templateUrl: './test-angular-editor.component.html',
  styleUrls: ['./test-angular-editor.component.css']
})
export class TestAngularEditorComponent implements OnInit {
  formGroup!: FormGroup;
  htmlContent = '';
  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    minHeight: '5rem',
    maxHeight: '15rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    sanitize: true,
    toolbarPosition: 'top',
    defaultFontName: 'Comic Sans MS',
    defaultFontSize: '5',
    defaultParagraphSeparator: 'p',
    toolbarHiddenButtons: [
      ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull']
    ],
    customClasses: [
      {
        name: 'quote',
        class: 'quote',
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: 'titleText',
        class: 'titleText',
        tag: 'h1',
      },
    ]
  };

  constructor() {}

  ngOnInit(): void {
    this.createReactiveForm();
  }

  onChange(event: any): void {
    console.log('\"%s\" %o', event, this.formGroup.value);
  }

  onSetValueClick(): void {
    const editor = this.formGroup.get('editorContent');
    if (!editor) {
      return;
    }

    editor.setValue('<img src=x onerror=alert(document.cookie)>');
  }

  private createReactiveForm(): void {
    this.formGroup = new FormGroup({
      editorContent: new FormControl('', [Validators.required])
    });
  }
}
