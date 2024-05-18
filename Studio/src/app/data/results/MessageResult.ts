export interface MessageResults<T>{
    results: T[],
    totalRecords: number,
    isSuccess: boolean,
}

export interface MessageResult<T>{
    result: T,
    totalRecords: number,
    isSuccess: boolean,
    
}

export interface MessageResultNoRecord{
    totalRecords: number,
    isSuccess: boolean,
}