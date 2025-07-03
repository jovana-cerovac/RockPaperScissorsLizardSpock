import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { GameRound, PlayRequest, PlayResponse } from '../models';

export const gameApi = createApi({
  reducerPath: 'gameApi',
  baseQuery: fetchBaseQuery({
    baseUrl: process.env.REACT_APP_GAME_API_BASE_URL
  }),
  tagTypes: ['GameRounds'],
  endpoints: (builder) => ({
    playRound: builder.mutation<PlayResponse, PlayRequest>({
      query: (data) => ({
        url: 'api/play',
        method: 'POST',
        body: data
      }),
      invalidatesTags: ['GameRounds']
    }),
    getGameRounds: builder.query<GameRound[], number | void>({
      query: (count = 10) => `api/gamerounds?count=${count}`,
      providesTags: ['GameRounds']
    }),
    deleteAllRounds: builder.mutation<void, void>({
      query: () => ({
        url: 'api/gamerounds',
        method: 'DELETE'
      }),
      invalidatesTags: ['GameRounds']
    })
  })
});

export const {
  usePlayRoundMutation,
  useGetGameRoundsQuery,
  useDeleteAllRoundsMutation
} = gameApi;
