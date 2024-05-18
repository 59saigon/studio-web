import { BaseEntity } from "./BaseEntity";
import { Role } from "./Role";

export interface User extends BaseEntity {
    fullName: string; // Required field, not nullable
    email?: string;   // Nullable
    dob: Date;        // Required field
    address?: string; // Nullable
    gender?: string;  // Nullable
    phone: string;    // Required field, not nullable
    username: string; // Required field, not nullable
    password: string; // Required field, not nullable
    roleId: string;   // RoleId as a UUID/GUID, could be a string in TypeScript
    avatar?: string;  // Nullable
    status?: string;  // Nullable
    role: Role;       // Required field, assuming it's a reference to a Role object
}
