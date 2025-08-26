export interface MenuItem {
  label: string;
  icon: string;
  link: string;
  show?: boolean;
  isTitle?: boolean;
  infoContent?: string;
  count?: boolean;
  children?: MenuItem[];
}