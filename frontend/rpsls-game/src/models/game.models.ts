export interface PlayRequest {
  player: number;
}

export interface PlayResponse {
  results: string;
  player: number;
  computer: number;
}

export interface GameRound {
  id: string;
  player: number;
  computer: number;
  result: string;
  playedAt: string;
}
