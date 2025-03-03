// https://stackoverflow.com/questions/36745734/how-to-add-conditional-attribute-in-angular-2
// https://www.developer.com/java/data/applying-conditional-styles-to-components-using-angular-declarations/

import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-test-conditional-attributes',
  templateUrl: './test-conditional-attributes.component.html',
  styleUrls: ['./test-conditional-attributes.component.css']
})
export class TestConditionalAttributesComponent {
  @Input() isCkecked1: boolean;
  @Input() isCkecked2: boolean;
  @Input() isCkecked3: boolean;
  @Input() isCkecked4: boolean;
  @Input() isInputText1Required: boolean;
  @Input() isInputText2Required: boolean;
  @Input() step1: string;
  @Input() step2: string;
  @Input() step3: string;
  @Input() step4: string;
}
