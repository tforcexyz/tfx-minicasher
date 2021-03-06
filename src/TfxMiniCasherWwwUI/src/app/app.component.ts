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

  private menus: NbMenuItem[] = [
    {
      title: 'Dashboard',
      link: 'dashboard',
      icon: { icon: 'chart-pie', pack: 'far' },
      home: true,
    },
    {
      title: 'TRANSACTION',
      group: true,
    },
    {
      title: 'Transaction',
      link: 'transaction/general-ledger',
      icon: { icon: 'exchange', pack: 'far' },
    },
    {
      title: 'Recurring transaction',
      link: 'transaction/recurring',
      icon: { icon: 'alarm-clock', pack: 'far' },
    },
    {
      title: 'MASTER DATA',
      group: true,
    },
    {
      title: 'Account',
      link: 'management/account',
      icon: { icon: 'landmark', pack: 'far' },
    },
    {
      title: 'Category',
      link: 'management/category',
      icon: { icon: 'list', pack: 'far' },
    },
    {
      title: 'REPORT',
      group: true,
    },
    {
      title: 'Balance',
      link: 'report/balance-sheet',
      icon: { icon: 'balance-scale', pack: 'far' },
    },
    {
      title: 'Expense',
      link: 'report/expense',
      icon: { icon: 'chart-line-down', pack: 'far' },
    },
    {
      title: 'Income',
      link: 'report/income',
      icon: { icon: 'chart-line', pack: 'far' },
    },
  ];

  constructor(private iconLibraries: NbIconLibraries) {
    this.iconLibraries.registerFontPack('fa', { packClass: 'fa', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('fas', { packClass: 'fas', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('fad', { packClass: 'fad', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('fal', { packClass: 'fal', iconClassPrefix: 'fa' });
    this.iconLibraries.registerFontPack('far', { packClass: 'far', iconClassPrefix: 'fa' });
  }
}
