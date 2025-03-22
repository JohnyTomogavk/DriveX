import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AppPrimeNgModule } from '../../modules/app-prime-ng.module';
import { MenuItem } from 'primeng/api';
import { NgOptimizedImage } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-navigation-layout-component',
  imports: [
    AppPrimeNgModule,
    NgOptimizedImage,
    RouterOutlet,
    RouterLink,
  ],
  templateUrl: './app-navigation-layout.component.html',
  styleUrl: './app-navigation-layout.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
})
export class AppNavigationLayoutComponent implements OnInit {
  public items: MenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      { label: 'Домашняя страница', icon: 'pi pi-home', routerLink: '/home' },
      { label: 'Расписание', icon: 'pi pi-calendar', routerLink: '/home' },
      { label: 'Чаты', icon: 'pi pi-comment', routerLink: '/home' },
      { label: 'Автопарк', icon: 'pi pi-car', routerLink: '/home' },
      { label: 'Учебные группы', icon: 'pi pi-users', routerLink: '/home' },
      { label: 'Аналитика', icon: 'pi pi-chart-bar', routerLink: '/home' },
      { label: 'Тесты по ПДД', icon: 'pi pi-check', routerLink: '/home' },
      { label: 'Управление пользователями', icon: 'pi pi-user', routerLink: '/home' },
      { label: 'Управление филиалами', icon: 'pi pi-building', routerLink: '/home' },
      { label: 'Маршруты ГАИ', icon: 'pi pi-map', routerLink: '/' },
    ];
  }
}
