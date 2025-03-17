import { NgModule } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { MenuModule } from 'primeng/menu';
import { RippleModule } from 'primeng/ripple';
import { StyleClassModule } from 'primeng/styleclass';
import { BadgeModule } from 'primeng/badge';
import { AvatarModule } from 'primeng/avatar';
import { CommonModule } from '@angular/common';
import { ToolbarModule } from 'primeng/toolbar';
import { InputTextModule } from 'primeng/inputtext';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { PopoverModule } from 'primeng/popover';

@NgModule({
  imports: [
    CommonModule,
    ButtonModule,
    MenuModule,
    RippleModule,
    StyleClassModule,
    BadgeModule,
    AvatarModule,
    ToolbarModule,
    InputTextModule,
    InputGroupModule,
    InputGroupAddonModule,
    PopoverModule,
  ],
  exports: [
    CommonModule,
    ButtonModule,
    MenuModule,
    RippleModule,
    StyleClassModule,
    BadgeModule,
    AvatarModule,
    ToolbarModule,
    InputTextModule,
    InputGroupModule,
    InputGroupAddonModule,
    PopoverModule,
  ],
  providers: [],
})
export class AppPrimeNgModule {
}
