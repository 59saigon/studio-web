export interface Login{
    username?: string,
    password?: string,
}

export interface Token{
    username: string,
    token: string,
    expiration: string,
}