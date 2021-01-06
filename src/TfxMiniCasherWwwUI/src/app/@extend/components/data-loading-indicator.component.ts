import { Component } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input } from '@angular/core';
import { Output } from '@angular/core';

@Component({
  selector: 'data-loading-indicator',
  templateUrl: './data-loading-indicator.component.html',
})
export class DataLoadingIndicatorComponent {

  @Input() isEmpty: boolean;
  @Input() isError: boolean;
  @Input() isLoaded: boolean;
  @Input() useSpinner: boolean;

  @Output() retry: EventEmitter<void> = new EventEmitter<void>();

  onRetryClick() {
    this.retry.emit();
  }
}
