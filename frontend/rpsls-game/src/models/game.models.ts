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
  playerChoiceId: number;
  computerChoiceId: number;
  outcome: number;
  playedAt: string;
}

export class ScoreboardRow {
  constructor(
    public playerChoice: string,
    public computerChoice: string,
    public outcomeMessage: string,
    public playedAt: Date
  ) {}
}
