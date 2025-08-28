export enum eRoleEnum {
  SuperAdmin = 1,
  Admin = 2,
  Seller = 3,
  User = 4,
  // Add other roles as needed
}

export interface loginDto{
  email : string | null;
  password : string | null;
}
