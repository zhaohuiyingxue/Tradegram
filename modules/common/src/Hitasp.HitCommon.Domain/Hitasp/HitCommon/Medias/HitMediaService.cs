using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MimeDetective.Extensions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Storage;

namespace Hitasp.HitCommon.Medias
{
    public abstract class HitMediaService<TMedia, TMediaRepository> : IMediaService<TMedia>, ITransientDependency
        where TMedia : Media, IMedia, new()
        where TMediaRepository : IMediaRepository<TMedia>
    {
        public ILogger<HitMediaService<TMedia, TMediaRepository>> Logger { get; set; }

        private readonly IGuidGenerator _guidGenerator;
        private readonly TMediaRepository _mediaRepository;
        private readonly IAbpStore _store;

        protected HitMediaService(
            [NotNull] TMediaRepository mediaRepository,
            [NotNull] string defaultStoreName,
            IAbpStorageFactory storageFactory,
            IGuidGenerator guidGenerator)
        {
            _mediaRepository = mediaRepository;
            _guidGenerator = guidGenerator;
            _store = storageFactory.GetStore(defaultStoreName);

            Logger = NullLogger<HitMediaService<TMedia, TMediaRepository>>.Instance;
        }

        public async Task<string> GetMediaUrl(TMedia media)
        {
            return await GetMediaUrl(media == null ? "no-image.png" : media.FileName);
        }

        public async Task<string> GetMediaUrl(string uniqueFileName)
        {
            var media = await _mediaRepository.FindByUniqueFileName(uniqueFileName);
            var file = await _store.GetAsync(media.ToString());

            return file.Path;
        }

        public async Task<TMedia> SaveMediaAsync(Stream mediaBinaryStream, string fileName, string rootDirectory)
        {
            var media = new TMedia
            {
                Id = _guidGenerator.Create(),
                FileName = fileName,
                RootDirectory = rootDirectory
            };


            var fileType = await mediaBinaryStream.GetFileTypeAsync();
            media.MimeType = fileType.Mime;
            media.FileExtension = fileType.ToString();

            await _store.SaveAsync(
                mediaBinaryStream,
                media.ToString(),
                media.MimeType);

            return await _mediaRepository.InsertAsync(media);
        }

        public async Task DeleteMediaAsync(TMedia media)
        {
            await _store.DeleteAsync(Path.Combine(media.RootDirectory, media.UniqueFileName));
            await _mediaRepository.DeleteAsync(media.Id);
        }

        public async Task DeleteMediaAsync(string uniqueFileName)
        {
            var media = await _mediaRepository.FindByUniqueFileName(uniqueFileName);
            await DeleteMediaAsync(media);
        }
    }
}