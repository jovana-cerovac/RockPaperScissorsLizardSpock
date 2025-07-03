import './Header.css';

export const Header = () => {
  return (
    <header className="header-container">
      <h1 className="header-title">Rock, Paper, Scissors, Lizard, Spock</h1>
      <div className="tooltip">
        Rules
        <div className="tooltip-text">
          <ul>
            <li>Rock crushes Scissors</li>
            <li>Scissors cuts Paper</li>
            <li>Paper covers Rock</li>
            <li>Rock crushes Lizard</li>
            <li>Lizard poisons Spock</li>
            <li>Spock smashes Scissors</li>
            <li>Scissors decapitates Lizard</li>
            <li>Lizard eats Paper</li>
            <li>Paper disproves Spock</li>
            <li>Spock vaporizes Rock</li>
          </ul>
        </div>
      </div>
    </header>
  );
};
