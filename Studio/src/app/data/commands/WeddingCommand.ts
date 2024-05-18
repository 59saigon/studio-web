import { Guid } from 'guid-typescript';
import {
  CreateCommand,
  DeleteCommand,
  UpdateCommand,
} from './BaseCommand';

export interface WeddingCreateCommand extends CreateCommand {
  weddingTittle: string; // Corrected spelling
  weddingDescription?: string; // Optional field
  status?: string; // Optional field
  startDate: Date; // Date in TypeScript
  endDate: Date;
  id?: Guid,
  createdBy: string;
  createdDate: Date;
  lastUpdatedBy: string;
  lastUpdatedDate?: Date; // Optional Date
  isDeleted: boolean;
}

export interface WeddingUpdateCommand extends UpdateCommand {
  weddingTittle: string; // Corrected spelling
  weddingDescription?: string; // Optional field
  status?: string; // Optional field
  startDate: Date; // Date in TypeScript
  endDate: Date;
  lastUpdatedBy: string;
  lastUpdatedDate?: Date; // Optional Date
  isDeleted: boolean;
}

export interface WeddingDeleteCommand extends DeleteCommand {}