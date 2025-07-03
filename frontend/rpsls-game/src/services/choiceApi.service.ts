import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Choice } from '../models';

export const choiceApi = createApi({
  reducerPath: 'choiceApi',
  baseQuery: fetchBaseQuery({
    baseUrl: process.env.REACT_APP_CHOICE_API_BASE_URL
  }),
  endpoints: (builder) => ({
    getAllChoices: builder.query<Choice[], void>({
      query: () => 'api/choices'
    })
  })
});

export const { useGetAllChoicesQuery } = choiceApi;
