import { Component } from '@angular/core';
import { NbIconLibraries } from '@nebular/theme';
import { NbMenuItem } from '@nebular/theme';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  title = 'Angular10 Webpack';

  constructor(private iconLibraries: NbIconLibraries) {
    this.iconLibraries.registerFontPack('fa', { packClass: 'fa', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('fas', { packClass: 'fas', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('fad', { packClass: 'fad', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('fal', { packClass: 'fal', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('far', { packClass: 'far', iconClassPrefix: 'fa' });
  }

  private menus: NbMenuItem[] = [
    {
      title: 'Dashboard',
      link: '.',
      icon: { icon: 'chart-pie', pack: 'far' },
      home: true,
    },
    {
      title: 'TRANSACTION',
      group: true,
    },
    {
      title: 'Transaction',
      link: '.',
      icon: { icon: 'exchange', pack: 'far' },
    },
    {
      title: 'Recurring transaction',
      link: '.',
      icon: { icon: 'alarm-clock', pack: 'far' },
    },
    {
      title: 'MASTER DATA',
      group: true,
    },
    {
      title: 'Account',
      link: '.',
      icon: { icon: 'landmark', pack: 'far' },
    },
    {
      title: 'Category',
      link: '.',
      icon: { icon: 'list', pack: 'far' },
    },
    {
      title: 'REPORT',
      group: true,
    },
    {
      title: 'Balance',
      link: '.',
      icon: { icon: 'balance-scale', pack: 'far' },
    },
    {
      title: 'Expense',
      link: '.',
      icon: { icon: 'chart-line-down', pack: 'far' },
    },
    {
      title: 'Income',
      link: '.',
      icon: { icon: 'chart-line', pack: 'far' },
    },
  ];
}
