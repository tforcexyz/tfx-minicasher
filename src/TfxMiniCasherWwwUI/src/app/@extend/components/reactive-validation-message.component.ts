import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Input } from '@angular/core';

@Component({
  selector: 'reactive-validation-message',
  templateUrl: './reactive-validation-message.component.html',
})
export class ReactiveValidationMessage {

  @Input() controlName: string;
  @Input() form: FormGroup;
  @Input() propertyName: string;

  get control() {
    return this.form.get(this.controlName);
  }
}
