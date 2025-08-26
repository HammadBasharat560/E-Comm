import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatBadgeModule } from '@angular/material/badge';
import { MatDividerModule } from '@angular/material/divider';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  imports: [CommonModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatBadgeModule,
    MatDividerModule]
})
export class HeaderComponent {
  @Input() appName = 'E-Sahulat Shopping';
  @Input() sidebarCollapsed = false;
  @Output() toggleSidebar = new EventEmitter<void>();

    notificationCount = 3;
  notifications = [
    { icon: 'mail', message: 'New message received' },
    { icon: 'event', message: 'Meeting in 15 minutes' },
    { icon: 'warning', message: 'System update required' }
  ];
    onToggleSidebar() {
    this.toggleSidebar.emit();
  }

  editProfile() {
    console.log('Edit profile clicked');
    // Add your edit profile logic here
  }

  changePassword() {
    console.log('Change password clicked');
    // Add change password logic here
  }

  logout() {
    console.log('Logout clicked');
    // Add logout logic here
  }

  markAllAsRead() {
    this.notificationCount = 0;
    this.notifications = [];
  }
}
