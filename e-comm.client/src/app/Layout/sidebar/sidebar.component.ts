import { Component, EventEmitter, inject, Injectable, Input, OnInit, Output } from '@angular/core';
import { MenuItem } from '../../Models/menu.model';
import { Route, Router } from '@angular/router';
import { getMenuItems } from '../menu';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatBadgeModule } from '@angular/material/badge';
import { MatDividerModule } from '@angular/material/divider';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
  imports: [CommonModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatBadgeModule,
    MatDividerModule]
})

export class SidebarComponent implements OnInit {
  @Input() isCollapsed = false;
  @Output() toggleSidebar = new EventEmitter<boolean>();

  menuItem: MenuItem[] = [];
  expandedItems: { [key: string]: boolean } = {};
  
  constructor(private router: Router) { }

  ngOnInit(): void {
    this.menuItem = getMenuItems();
  }

  toggleCollapse(): void {
    this.isCollapsed = !this.isCollapsed;
    this.toggleSidebar.emit(this.isCollapsed);
  }

  toggleSubmenu(item: MenuItem): void {
    if (item.children && item.children.length > 0) {
      this.expandedItems[item.label] = !this.expandedItems[item.label];
    } else {
      this.navigateToPage(item.link);
    }
  }

  navigateToPage(link: string): void {
    this.router.navigate([link]);
  }

  isExpanded(item: MenuItem): boolean {
    return this.expandedItems[item.label] || false;
  }
}
