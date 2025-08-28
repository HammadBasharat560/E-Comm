import { Injectable } from "@angular/core";
import { eRoleEnum } from "../components/auth/auth.model";
import { MenuItem } from "../Models/menu.model";


export function getMenuItems(): MenuItem[] {
  const eRole = Number(localStorage.getItem('eRole'));

  return [
    {
      label: 'Dashboard',
      icon: 'dashboard',
      link: '/dashboard',
      show: true,
    },
    {
      label: 'Products',
      icon: 'inventory',
      link: '/products',
      show: true,
      children: [
        {
          label: 'All Products',
          icon: 'list',
          link: '/auth/login',
          show: true,
        },
        {
          label: 'Add Product',
          icon: 'add_box',
          link: '/products/add',
          show: eRole === eRoleEnum.Admin || eRole === eRoleEnum.Seller,
        },
        {
          label: 'Categories',
          icon: 'category',
          link: '/products/categories',
          show: eRole === eRoleEnum.Admin,
        },
        {
          label: 'Inventory',
          icon: 'inventory_2',
          link: '/products/inventory',
          show: eRole === eRoleEnum.Admin || eRole === eRoleEnum.Seller,
        }
      ]
    },
    {
      label: 'Orders',
      icon: 'shopping_cart',
      link: '/orders',
      show: true,
      children: [
        {
          label: 'All Orders',
          icon: 'receipt_long',
          link: '/orders/list',
          show: true,
        },
        {
          label: 'Pending Orders',
          icon: 'pending',
          link: '/orders/pending',
          show: true,
        },
        {
          label: 'Completed Orders',
          icon: 'check_circle',
          link: '/orders/completed',
          show: true,
        },
        {
          label: 'Cancelled Orders',
          icon: 'cancel',
          link: '/orders/cancelled',
          show: true,
        }
      ]
    },
    {
      label: 'Customers',
      icon: 'people',
      link: '/customers',
      show: eRole === eRoleEnum.Admin || eRole === eRoleEnum.Seller,
      children: [
        {
          label: 'All Customers',
          icon: 'group',
          link: '/customers/list',
          show: true,
        },
        {
          label: 'Add Customer',
          icon: 'person_add',
          link: '/customers/add',
          show: eRole === eRoleEnum.Admin,
        }
      ]
    },
    {
      label: 'Sales',
      icon: 'trending_up',
      link: '/sales',
      show: eRole === eRoleEnum.Admin || eRole === eRoleEnum.Seller,
      children: [
        {
          label: 'Sales Report',
          icon: 'analytics',
          link: '/sales/report',
          show: true,
        },
        {
          label: 'Revenue',
          icon: 'attach_money',
          link: '/sales/revenue',
          show: true,
        }
      ]
    },
    {
      label: 'Settings',
      icon: 'settings',
      link: '/settings',
      show: eRole === eRoleEnum.Admin,
      children: [
        {
          label: 'General Settings',
          icon: 'tune',
          link: '/settings/general',
          show: true,
        },
        {
          label: 'User Management',
          icon: 'admin_panel_settings',
          link: '/settings/users',
          show: true,
        },
        {
          label: 'System Configuration',
          icon: 'build',
          link: '/settings/system',
          show: true,
        }
      ]
    },
    {
      label: 'Reports',
      icon: 'assessment',
      link: '/reports',
      show: eRole === eRoleEnum.Admin,
      children: [
        {
          label: 'Sales Reports',
          icon: 'bar_chart',
          link: '/reports/sales',
          show: true,
        },
        {
          label: 'Inventory Reports',
          icon: 'pie_chart',
          link: '/reports/inventory',
          show: true,
        },
        {
          label: 'Customer Reports',
          icon: 'people_alt',
          link: '/reports/customers',
          show: true,
        }
      ]
    }
  ].filter(item => item.show !== false);
}