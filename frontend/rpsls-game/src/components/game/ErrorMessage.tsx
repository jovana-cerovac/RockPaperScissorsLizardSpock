import './GameConsole.css';

interface ErrorMessageProps {
  message: string;
}

export const ErrorMessage = ({ message }: ErrorMessageProps) => {
  return <p className="error">{message}</p>;
};
