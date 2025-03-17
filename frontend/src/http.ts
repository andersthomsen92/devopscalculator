import {Api} from "./Api.ts";

export const baseUrl = "http://localhost:5000";
export const stageUrl = "http://79.76.54.224";

export const http = new Api({
    baseURL: stageUrl
});