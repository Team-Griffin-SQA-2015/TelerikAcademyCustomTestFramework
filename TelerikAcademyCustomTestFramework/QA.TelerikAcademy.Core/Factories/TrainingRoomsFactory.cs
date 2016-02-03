namespace QA.TelerikAcademy.Core.Factories
{
    #region using directives

    using System;

    using Constants.Pages;

    using Enumerations;

    using TestingFramework.Core.Data;

    #endregion

    public static class TrainingRoomsFactory
    {
        public static TrainingRoom Get(TrainingRoomType trainingRoom)
        {
            switch (trainingRoom)
            {
                case TrainingRoomType.Valid:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.ValidForMultiAdd:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidNameForMultiAdd,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.BlankName:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.EmptyName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.TooLongName:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.FiftyOneCharactersName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.SpecialCharactersName:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.SpecialCharactersName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.TooLongAddress:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.TwoHundredAndFiftyOneCharactersAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.SpecialCharactersAddress:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.SpecialCharactersAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.TooLongCapacity:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.FiftyOneCharactersCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.LettersCapacity:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.LettersCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.SpecialCharactersCapacity:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.SpecialCharactersCapacity,
                        Equipment = TrainingRoomConstants.ValidEquipment
                    };
                case TrainingRoomType.TooLongEquipment:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.TwoHundredAndFiftyOneCharactersEquipment
                    };
                case TrainingRoomType.SpecialCharactersEquipment:
                    return new TrainingRoom
                    {
                        Name = TrainingRoomConstants.ValidName,
                        Address = TrainingRoomConstants.ValidAddress,
                        Capacity = TrainingRoomConstants.ValidCapacity,
                        Equipment = TrainingRoomConstants.SpecialCharacterEquipment
                    };
                default:
                    throw new ArgumentException();
            }
        }
    }
}