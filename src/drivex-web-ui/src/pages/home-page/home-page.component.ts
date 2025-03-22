import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-navigation-layout-home-page',
  imports: [],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomePageComponent {
}
