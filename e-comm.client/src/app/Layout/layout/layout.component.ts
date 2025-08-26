import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from '../header/header.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-layout',
  standalone: true,
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css',
  imports: [HeaderComponent, SidebarComponent, FooterComponent]
})
export class LayoutComponent {
  sidebarCollapsed = false;

  onToggleSidebar() {
    this.sidebarCollapsed = !this.sidebarCollapsed;
  }

  onSidebarToggle(collapsed: boolean) {
    this.sidebarCollapsed = collapsed;
  }
}
