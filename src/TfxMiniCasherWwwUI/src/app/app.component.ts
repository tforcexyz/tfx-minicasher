import { Component } from '@angular/core';
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
      link: '.',
      icon: 'home-outline',
      home: true,
    },
    {
      title: 'GROUP',
      group: true,
    },
    {
      title: 'Level 1',
      link: '.',
      icon: 'list',
      children: [
        {
          title: 'Level 1.1',
          link: '.',
        },
      ]
    },
  ];
}
