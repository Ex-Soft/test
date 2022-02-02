import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormControl, AbstractControl } from '@angular/forms';

import { Validators, Editor, Toolbar } from "ngx-editor";

@Component({
  selector: 'app-test-ngx-editor',
  templateUrl: './test-ngx-editor.component.html',
  styleUrls: ['./test-ngx-editor.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class TestNgxEditorComponent implements OnInit, OnDestroy {
  formGroup!: FormGroup;
  editor!: Editor;
  toolbar: Toolbar = [
    ["bold", "italic"],
    ["underline", "strike"],
    ["code", "blockquote"],
    ["ordered_list", "bullet_list"],
    [{ heading: ["h1", "h2", "h3", "h4", "h5", "h6"] }],
    ["link", "image"],
    ["text_color", "background_color"] /*,
    ["align_left", "align_center", "align_right", "align_justify"]*/
  ];

  constructor() {}

  ngOnInit(): void {
    this.editor = new Editor();
    this.createReactiveForm();
  }

  ngOnDestroy(): void {
      this.editor.destroy();
  }

  private createReactiveForm(): void {
    this.formGroup = new FormGroup({
      editorContent: new FormControl({ value: '', disabled: false}, Validators.required())
    });
  }
}
