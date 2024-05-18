import { Guid } from "guid-typescript";

export interface BaseCommand{

}

export interface CreateCommand extends BaseCommand{

}

export interface UpdateCommand extends BaseCommand{
    id: Guid
}

export interface DeleteCommand extends BaseCommand{
    id: Guid
}