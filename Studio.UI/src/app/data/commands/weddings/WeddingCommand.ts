import { Guid } from 'guid-typescript';
import {
  BaseCommand,
  CreateCommand,
  DeleteCommand,
  UpdateCommand,
} from '../BaseCommand';

export interface WeddingCreateCommand extends CreateCommand {
  weddingTittle: string; // Corrected spelling
  weddingDescription?: string; // Optional field
  status?: string; // Optional field
  startDate: Date; // Date in TypeScript
  endDate: Date;
  createdBy: string;
  createdDate: Date;
  lastUpdatedBy: string;
  lastUpdatedDate?: Date; // Optional Date
  isDeleted: boolean;
}

export interface WeddingUpdateCommand extends UpdateCommand {}

export interface WeddingDeleteCommand extends DeleteCommand {}
