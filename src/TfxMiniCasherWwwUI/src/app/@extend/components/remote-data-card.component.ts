import { Component } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input } from '@angular/core';
import { Output } from '@angular/core';

@Component({
  selector: 'remote-data-card',
  templateUrl: './remote-data-card.component.html',
})
export class RemoteDataCardComponent {

  @Input() className: string;
  @Input() isEmpty: boolean;
  @Input() isError: boolean;
  @Input() isLoaded: boolean;
  @Input() isWaiting: boolean;
  @Input() hasFooter: boolean;
  @Input() title: string;
  @Input() useSpinner: boolean;

  @Output() retry: EventEmitter<void> = new EventEmitter<void>();

  onRetryClick() {
    this.retry.emit();
  }
}
