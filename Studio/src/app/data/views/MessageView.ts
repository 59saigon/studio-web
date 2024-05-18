export interface MessageViews<T>{
    views: T[],
    totalRecords: number,
    isSuccess: boolean,
}

export interface MessageView<T>{
    view: T,
    totalRecords: number,
    isSuccess: boolean,
    
}

export interface MessageViewNoRecord{
    totalRecords: number,
    isSuccess: boolean,
}