import { useEffect } from 'react';
import { useGetAllChoicesQuery, usePlayRoundMutation } from './services';

function App() {
  const { data: choices } = useGetAllChoicesQuery();

  const [playRound] = usePlayRoundMutation();

  useEffect(() => {
    playRound({ player: 2 });
  }, []);

  return (
    <div>
      {choices ? choices.map((choice) => choice.name).join(' * ') : <></>}
    </div>
  );
}

export default App;
