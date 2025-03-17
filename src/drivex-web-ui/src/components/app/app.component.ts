import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { AppPrimeNgModule } from '../../modules/app-prime-ng.module';
import { MenuItem } from 'primeng/api';
import { NgOptimizedImage } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [
    AppPrimeNgModule,
    NgOptimizedImage,
    RouterOutlet,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
  encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
  items: MenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      { label: 'Домашняя страница', icon: 'pi pi-home' },
      { label: 'Расписание', icon: 'pi pi-calendar' },
      { label: 'Чаты', icon: 'pi pi-comment' },
      { label: 'Автопарк', icon: 'pi pi-car' },
      { label: 'Учебные группы', icon: 'pi pi-users' },
      { label: 'Аналитика', icon: 'pi pi-chart-bar' },
      { label: 'Тесты по ПДД', icon: 'pi pi-check' },
      { label: 'Управление пользователями', icon: 'pi pi-user' },
      { label: 'Управление филиалами', icon: 'pi pi-building' },
      { label: 'Маршруты ГАИ', icon: 'pi pi-map' },
    ];
  }
}
