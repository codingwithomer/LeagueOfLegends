using LeagueOfLegends.Character.Factory;
using LeagueOfLegends.Common.Validators.Abracts;
using LeagueOfLegends.Business.Abracts;
using System;
using System.Threading;
using LeagueOfLegends.Common.Enums;
using LeagueOfLegends.Common.Validators.Concretes;
using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business
{
    public class GameManager : IGameService
    {
        private readonly ICharacterService _characterService;
        private readonly IHealthEquipmentService _healthEquipmentService;
        private readonly ICharacterFactory _characterFactory;
        private readonly IValidatorFactory _validator;

        public GameManager(ICharacterFactory characterFactory, IValidatorFactory validator,ICharacterService characterService, IHealthEquipmentService healthEquipmentService)
        {
            _characterFactory = characterFactory;
            _validator = validator;
            _characterService = characterService;
            _healthEquipmentService = healthEquipmentService;
        }

        public void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("League of Legends'a hoşgeldiniz.");
            Thread.Sleep(2500);
            Console.Clear();
        }

        public void Run()
        {
            #region Character Selection
            bool isCharacterValid = false;

            int characterType = 0;

            CharacterInputValidator characterValidator = (CharacterInputValidator)_validator.CreateValidator(ValidatorType.CharacterInputValidator);

            while (!isCharacterValid)
            {
                _characterService.DisplayCharacterMenu();

                string input = _characterService.GetCharacterInput();

                _characterService.ShowSelection(input);
                
                isCharacterValid = characterValidator.IsInputValid(input, ref characterType);

                Console.Clear();

                if (isCharacterValid == false)
                {
                    _characterService.ShowInvalidSelectionMessage();
                    continue;
                }
                else
                    break;
            }

            CharacterBase character = _characterFactory.CreateCharacter(characterType);

            if (!characterValidator.CharacterIsNull(character))
                Environment.Exit(0);

            #endregion

            #region Health Equipment Selection
            bool isHealtEquipmentValid = false;

            int healthEquipmentType = 0;

            HealthEquipmentValidator healthEquipmentValidator = (HealthEquipmentValidator)_validator.CreateValidator(ValidatorType.HealthEquipmentValidator);

            while (!isHealtEquipmentValid)
            {
                _healthEquipmentService.DisplayHealthEquipmentMenu();

                string input = _healthEquipmentService.GetHealthEquipmentInput();

                isHealtEquipmentValid = healthEquipmentValidator.IsInputValid(input, ref healthEquipmentType);

                if (isHealtEquipmentValid == false)
                    continue;
                else
                    break;
            }
            #endregion

            _characterService.ShowResult(character);
        }
    }
}
