export interface BaseQuery {}

export interface GetByIdQuery extends GetQueryableQuery {}

export interface GetAllQuery extends GetQueryableQuery {}

export interface GetQueryableQuery extends BaseQuery {
  fromDate?: Date | null;
  toDate?: Date | null;
}
