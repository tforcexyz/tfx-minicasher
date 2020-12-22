import { Component } from '@angular/core';
import { Input } from '@angular/core';

@Component({
  selector: 'page-header',
  styleUrls: ['./page-header.component.scss'],
  templateUrl: './page-header.component.html',
})
export class PageHeaderComponent {

  @Input() heading: string;
}
